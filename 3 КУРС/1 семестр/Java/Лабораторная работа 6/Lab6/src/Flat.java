import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Objects;

public class Flat
{
    private String regionName;
    private String streetName;
    private int id;
    private float square;
    private float kitchen;
    private float housingpart;
    private ArrayList<Float> rooms;
    private Map<String, String> seller;

    public Flat(String regionName, String streetName, int id, float square, float kitchen, float housingpart, ArrayList<Float> rooms, Map<String, String> seller) {
        this.regionName = regionName;
        this.streetName = streetName;
        this.id = id;
        this.square = square;
        this.kitchen = kitchen;
        this.rooms= new ArrayList<>(rooms);
        this.seller = new HashMap<>(seller);
        this.housingpart = housingpart;
    }

    public String toString(){
        String ret = String.format("Район: " + regionName + "\nПлощадь: " + square + "\nКухня: " + kitchen + "\nЖилая часть" +
                ": " + housingpart + "\nКомнаты: " + rooms.toString() + "\nПродавец: " + seller.toString()) + "\n";
        return ret;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Flat flat = (Flat) o;
        return id == flat.id &&
                Float.compare(flat.square, square) == 0 &&
                Float.compare(flat.kitchen, kitchen) == 0 &&
                Float.compare(flat.housingpart, housingpart) == 0 &&
                Objects.equals(regionName, flat.regionName) &&
                Objects.equals(streetName, flat.streetName) &&
                Objects.equals(rooms, flat.rooms) &&
                Objects.equals(seller, flat.seller);
    }

    @Override
    public int hashCode() {
        return Objects.hash(regionName, streetName, id, square, kitchen, housingpart, rooms, seller);
    }
}
