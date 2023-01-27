import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.junit.*;
import ru.javavision.dao.CarDAO;
import ru.javavision.dao.CustomerDAO;
import ru.javavision.dao.DAO;
import ru.javavision.dao.EngineDAO;
import ru.javavision.model.Car;
import ru.javavision.model.Customer;
import ru.javavision.model.Engine;
import java.util.HashSet;
import java.util.Set;
import static org.hamcrest.core.Is.is;
import static org.junit.Assert.*;
import lombok.Getter;
import lombok.Setter;

public class Test
{
    private SessionFactory factory;

    private DAO<Engine, Integer> engineDAO;

    private DAO<Car, Integer> carDAO;
    private DAO <Customer, Integer> customerDAO;

    private final Engine testEngine = new Engine();
    private final Customer testCustomer = new Customer();
    private final Car testCar = new Car();
    private final Car testCar2 = new Car();

    @Before
    public void beforeEngine() {
        factory = new Configuration().configure().buildSessionFactory();
        engineDAO = new EngineDAO(factory);

        testEngine.setId(1);
        testEngine.setName("super_engine");
        testEngine.setPower(10000);
        testEngine.setCarMark("ford");

    }

    @Before
    public void beforeCar() {
        factory = new Configuration().configure().buildSessionFactory();
        carDAO = new CarDAO(factory);

        testCar.setId(1);
        testCar.setCost(20000);
        testCar.setMark("ford");
    }

    @Before
    public void beforeCustomer(){
        factory = new Configuration().configure().buildSessionFactory();
        customerDAO = new CustomerDAO(factory);
        testCustomer.setId(1);
        testCustomer.setName("Андрей");
        testCustomer.setPhone("89532213951");
        testCustomer.setCar(testCar);
    }

    @Before
    public void beforeCars(){
        factory = new Configuration().configure().buildSessionFactory();
        engineDAO = new EngineDAO(factory);
        carDAO = new CarDAO(factory);
        testEngine.setId(1);
        testEngine.setCarMark("test-mark");
        testEngine.setPower(1000);
        testEngine.setName("test-name");

        testCar.setId(2);
        testCar.setMark("test-mark");
        testCar.setCost(10);

        testCar.setId(2);
        testCar2.setMark("test-mark");
        testCar2.setCost(20);

        Set<Car> cars = new HashSet<>();
        cars.add(testCar);
        cars.add(testCar2);
        testEngine.setCars(cars);

        //engineDAO.create(engine);
    }

   /* @After
    public void after() {
        if (engineDAO.read(1) != null) {
            engineDAO.delete(testEngine);
        }
        factory.close();
    }*/

    @org.junit.Test
    public void whenEngineIsCreateThenEngineIsExist() {
        engineDAO.create(testEngine);
        final Engine beforeEngine = engineDAO.read(testEngine.getId());
        assertEquals(beforeEngine.getName(), "super_engine");
        factory.close();
    }

    @org.junit.Test
    public void whenCarIsCreateThenCarIsExist() {
        carDAO.create(testCar);
        final Car beforeCar = carDAO.read(1);
        assertNotNull(beforeCar.getCost());
        assertEquals(beforeCar.getId(), 1);
        factory.close();
    }


    @org.junit.Test
    public void createOneToManyConnection() {
        carDAO.create(testCar);
        engineDAO.create(testEngine);
        final Engine beforeCars = engineDAO.read(testEngine.getId());
        //assertNotNull(beforeCars.getCost());
        assertNotNull(beforeCars.getCars());
        factory.close();
    }

    @org.junit.Test
    public void whenCustomerIsCreateThenCustomerIsExist() {
        customerDAO.create(testCustomer);
        final Customer beforeCustomer = customerDAO.read(1);
        assertNotNull(beforeCustomer.getPhone());
        assertEquals(beforeCustomer.getId(), 1);
        factory.close();
    }

    @org.junit.Test
    public void whenCarMarkUpdateThenNewCarMark() {
        carDAO.create(testCar);
        testCar.setMark("ford");
        carDAO.update(testCar);
        final Car after = carDAO.read(1);
        assertEquals(testCar.getMark(), "ford");
        factory.close();
    }

    @org.junit.Test
    public void whenCustomerPhoneIsUpdateThenCustomerHasNewPhone() {
        testCustomer.setPhone("89999999999");
        customerDAO.update(testCustomer);
        assertEquals(testCustomer.getPhone(), "89999999999");
        factory.close();
    }

    @org.junit.Test
    public void whenCustomerNameIsUpdateThenCustomerHasNewName() {
        testCustomer.setName("Алексей");
        customerDAO.update(testCustomer);
        assertEquals(testCustomer.getName(), "Алексей");
        factory.close();
    }

    @org.junit.Test
    public void whenCustomerIsDeleteThenCustomerIsNotExist() {
        customerDAO.create(testCustomer);
        customerDAO.delete(testCustomer);
        final Customer after = customerDAO.read(testCustomer.getId());
        assertNull(after);
        factory.close();
    }

    @org.junit.Test
    public void whenCarIsDeleteThenCarIsNotExist() {
        carDAO.create(testCar);
        carDAO.delete(testCar);
        final Car after = carDAO.read(testCar.getId());
        assertNull(after);
        factory.close();
    }
}
