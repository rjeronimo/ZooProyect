package pe.edu.zoo.model;
import org.junit.Test;
import org.springframework.roo.addon.test.RooIntegrationTest;

@RooIntegrationTest(entity = Person.class, transactional = false)
public class PersonIntegrationTest {

    @Test
    public void testMarkerMethod() {
    }
}
