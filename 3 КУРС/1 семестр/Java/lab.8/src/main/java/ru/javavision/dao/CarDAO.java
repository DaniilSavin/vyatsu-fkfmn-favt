package ru.javavision.dao;

import org.hibernate.Hibernate;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.jetbrains.annotations.NotNull;
import ru.javavision.model.Car;
import lombok.Getter;
import lombok.Setter;

public class CarDAO implements DAO<Car, Integer> {

    private final SessionFactory factory;

    public CarDAO(@NotNull final SessionFactory factory) {
        this.factory = factory;
    }

    @Override
    public void create(@NotNull final Car car) {

        try (final Session session = factory.openSession()) {

            session.beginTransaction();

            session.save(car);

            session.getTransaction().commit();
        }
    }

    @Override
    public Car read(@NotNull final Integer id) {

        try (final Session session = factory.openSession()) {

            final Car result = session.get(Car.class, id);

            if (result != null) {
                Hibernate.initialize(result.getId());

            }

            return result;
        }
    }

    @Override
    public void update(@NotNull final Car car) {

        try (Session session = factory.openSession()) {

            session.beginTransaction();

            session.update(car);

            session.getTransaction().commit();
        }
    }

    @Override
    public void delete(@NotNull final Car car) {

        try (Session session = factory.openSession()) {

            session.beginTransaction();

            session.delete(car);

            session.getTransaction().commit();
        }
    }
}