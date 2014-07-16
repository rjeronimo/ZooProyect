package pe.edu.zoo.repository;
import java.util.List;
import org.springframework.roo.addon.layers.repository.mongo.RooMongoRepository;
import pe.edu.zoo.model.Person;

@RooMongoRepository(domainType = Person.class)
public interface PersonRepository {

    List<Person> findAll();
}
