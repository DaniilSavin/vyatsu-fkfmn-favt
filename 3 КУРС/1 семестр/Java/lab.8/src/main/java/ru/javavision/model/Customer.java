package ru.javavision.model;

import lombok.*;

@Data
@NoArgsConstructor
@AllArgsConstructor
@ToString
@EqualsAndHashCode
public class Customer {

    private int id;

    private String name;

    private String phone;

    private Car car;
}