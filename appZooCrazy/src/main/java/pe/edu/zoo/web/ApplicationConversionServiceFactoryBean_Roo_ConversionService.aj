// WARNING: DO NOT EDIT THIS FILE. THIS FILE IS MANAGED BY SPRING ROO.
// You may push code into the target .java compilation unit if you wish to edit any member(s).

package pe.edu.zoo.web;

import java.math.BigInteger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Configurable;
import org.springframework.core.convert.converter.Converter;
import org.springframework.format.FormatterRegistry;
import pe.edu.zoo.model.Person;
import pe.edu.zoo.repository.PersonRepository;
import pe.edu.zoo.web.ApplicationConversionServiceFactoryBean;

privileged aspect ApplicationConversionServiceFactoryBean_Roo_ConversionService {
    
    declare @type: ApplicationConversionServiceFactoryBean: @Configurable;
    
    @Autowired
    PersonRepository ApplicationConversionServiceFactoryBean.personRepository;
    
    public Converter<Person, String> ApplicationConversionServiceFactoryBean.getPersonToStringConverter() {
        return new org.springframework.core.convert.converter.Converter<pe.edu.zoo.model.Person, java.lang.String>() {
            public String convert(Person person) {
                return new StringBuilder().append(person.getFirtsName()).append(' ').append(person.getLastName()).append(' ').append(person.getPhone()).append(' ').append(person.getDni()).toString();
            }
        };
    }
    
    public Converter<BigInteger, Person> ApplicationConversionServiceFactoryBean.getIdToPersonConverter() {
        return new org.springframework.core.convert.converter.Converter<java.math.BigInteger, pe.edu.zoo.model.Person>() {
            public pe.edu.zoo.model.Person convert(java.math.BigInteger id) {
                return personRepository.findOne(id);
            }
        };
    }
    
    public Converter<String, Person> ApplicationConversionServiceFactoryBean.getStringToPersonConverter() {
        return new org.springframework.core.convert.converter.Converter<java.lang.String, pe.edu.zoo.model.Person>() {
            public pe.edu.zoo.model.Person convert(String id) {
                return getObject().convert(getObject().convert(id, BigInteger.class), Person.class);
            }
        };
    }
    
    public void ApplicationConversionServiceFactoryBean.installLabelConverters(FormatterRegistry registry) {
        registry.addConverter(getPersonToStringConverter());
        registry.addConverter(getIdToPersonConverter());
        registry.addConverter(getStringToPersonConverter());
    }
    
    public void ApplicationConversionServiceFactoryBean.afterPropertiesSet() {
        super.afterPropertiesSet();
        installLabelConverters(getObject());
    }
    
}
