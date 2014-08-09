package edu.pe.zoocrazy.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.oxm.jaxb.Jaxb2Marshaller;

import edu.pe.zoocrazy.institute.InstituteClient;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ObjectFactory;

@Configuration
public class InstituteConfiguration {
	
	@Bean
	public Jaxb2Marshaller marshaller() {
		Jaxb2Marshaller marshaller = new Jaxb2Marshaller();
		marshaller.setContextPath(ObjectFactory.class.getPackage().getName());
		return marshaller;
	}

	@Bean
	public InstituteClient instituteClient(Jaxb2Marshaller marshaller) {
		InstituteClient client = new InstituteClient();
		client.setDefaultUri("http://localhost:3526/GestionarInstitucion.svc");
		client.setMarshaller(marshaller);
		client.setUnmarshaller(marshaller);
		return client;
	}
	
}
