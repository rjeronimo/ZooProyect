package pe.edu.zoo.model;
import org.springframework.roo.addon.javabean.RooJavaBean;
import org.springframework.roo.addon.layers.repository.mongo.RooMongoEntity;
import org.springframework.roo.addon.tostring.RooToString;
import javax.validation.constraints.NotNull;

@RooJavaBean
@RooToString
@RooMongoEntity
public class Person {

    /**
     */
    @NotNull
    private String firtsName;

    /**
     */
    @NotNull
    private String LastName;

    /**
     */
    private String phone;

    /**
     */
    @NotNull
    private String dni;

    /**
     */
    @NotNull
    private String password;
}
