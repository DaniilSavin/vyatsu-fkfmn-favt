package ru.javavision.dao;

import org.hibernate.Hibernate;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.jetbrains.annotations.NotNull;
import ru.javavision.model.Car;
import ru.javavision.model.Customer;

public class CustomerDAO implements DAO<Customer, Integer> {

    private final SessionFactory factory;

    public CustomerDAO(@NotNull final SessionFactory factory) {
        this.factory = factory;
    }

    @Override
    public void create(@NotNull final Customer customer) {

        try (final Session session = factory.openSession()) {

            session.beginTransaction();

            session.save(customer);

            session.getTransaction().commit();
        }
    }

    @Override
    public Customer read(@NotNull final Integer id) {

        try (final Session session = factory.openSession()) {

            final Customer result = session.get(Customer.class, id);

            if (result != null) {
                Hibernate.initialize(result.getId());
            }

            return result;
        }
    }

    @Override
    public void update(@NotNull final Customer customer) {

        try (Session session = factory.openSession()) {

            session.beginTransaction();

            session.update(customer);

            session.getTransaction().commit();
        }
    }

    @Override
    public void delete(@NotNull final Customer customer) {

        try (Session session = factory.openSession()) {

            session.beginTransaction();

            session.delete(customer);

            session.getTransaction().commit();
        }
    }
}