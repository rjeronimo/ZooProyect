package edu.pe.zoocrazy.institute;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ws.client.core.support.WebServiceGatewaySupport;
import org.springframework.ws.soap.client.SoapFaultClientException;
import org.springframework.ws.soap.client.core.SoapActionCallback;

import edu.pe.zoocrazy.config.InstituteConfiguration;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.Institucions;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ListaInstitucion;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ListaInstitucionResponse;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ObjectFactory;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ObtenerInstitucionRUC;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ObtenerInstitucionRUCResponse;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ObtenerInstitucionRazon;
import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.ObtenerInstitucionRazonResponse;

public class InstituteClient extends WebServiceGatewaySupport {
	
	public List<Institucions> listarIntitucionTodo()
			throws SoapFaultClientException {
		ListaInstitucion requestLista = new ListaInstitucion();
		System.out.println("Request all institution...");

		ListaInstitucionResponse responseLista = (ListaInstitucionResponse) getWebServiceTemplate()
				.marshalSendAndReceive(
						requestLista,
						new SoapActionCallback(
								"http://tempuri.org/IGestionarInstitucion/ListaInstitucion"));

		return responseLista.getListaInstitucionResult().getValue()
				.getInstitucions();

	}

	public Institucions obtenerInstitucionPorRuc(String ruc)
			throws SoapFaultClientException {
		System.out.println("obtenerInstitucionPorRuc " + ruc);
		ObjectFactory factory = new ObjectFactory();
		ObtenerInstitucionRUC request = factory.createObtenerInstitucionRUC();

		request.setRuc(factory.createObtenerInstitucionRUCRuc(ruc));

		ObtenerInstitucionRUCResponse obtenerInstitucion = (ObtenerInstitucionRUCResponse) getWebServiceTemplate()
				.marshalSendAndReceive(
						request,
						new SoapActionCallback(
								"http://tempuri.org/IGestionarInstitucion/ObtenerInstitucionRUC"));

		return obtenerInstitucion.getObtenerInstitucionRUCResult().getValue();
	}

	public Institucions obtenerInstitucionPorRazonSocial(String razon)
			throws SoapFaultClientException {
		System.out.println("obtenerInstitucionPorRazonSocial " + razon);
		ObjectFactory factory = new ObjectFactory();

		ObtenerInstitucionRazon request = factory
				.createObtenerInstitucionRazon();

		request.setRazon(factory.createObtenerInstitucionRazonRazon(razon));

		ObtenerInstitucionRazonResponse obtenerInstitucion = (ObtenerInstitucionRazonResponse) getWebServiceTemplate()
				.marshalSendAndReceive(
						request,
						new SoapActionCallback(
								"http://tempuri.org/IGestionarInstitucion/ObtenerInstitucionRazon"));

		return obtenerInstitucion.getObtenerInstitucionRazonResult().getValue();
	}

}
