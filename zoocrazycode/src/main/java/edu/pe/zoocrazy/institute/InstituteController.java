package edu.pe.zoocrazy.institute;

import java.util.ArrayList;
import java.util.List;

import javax.inject.Inject;
import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;
import org.springframework.ws.soap.client.SoapFaultClientException;

import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.Institucions;
import edu.pe.zoocrazy.support.web.MessageHelper;

@Controller
@RequestMapping(value="institute")
public class InstituteController {
	
	@Inject
	InstituteClient instituteClient;
	
	
	@RequestMapping(value="/viewInstitute")
	private String viewFormInstitute(Model model){
		model.addAttribute("instituciones", new ArrayList<Institucions>());
		return "/signup/listaInstituciones";
	}
	
	@RequestMapping(value="/showInstitute", method=RequestMethod.GET)
	public String showInstitute(@RequestParam String ruc, @RequestParam String razonSocial ,Model model, RedirectAttributes ra){
		List<Institucions> listaResponse = new ArrayList<Institucions>();
		try{
			if(!ruc.isEmpty())
				listaResponse.add(instituteClient.obtenerInstitucionPorRuc(ruc));
			else if(!razonSocial.isEmpty())
				listaResponse.add(instituteClient.obtenerInstitucionPorRazonSocial(razonSocial));
			else{
				listaResponse = instituteClient.listarIntitucionTodo();
			}
			System.out.println(listaResponse.size());
			model.addAttribute("instituciones", listaResponse);
		}catch(SoapFaultClientException soap){
			MessageHelper.addErrorAttribute(ra, soap.getMessage());
		}catch (Exception e) {
			System.out.println("====================================================");
			MessageHelper.addErrorAttribute(ra, e.getMessage());
		}finally{
			return "/signup/listaInstituciones";
		}
	}
	
	
	@RequestMapping(value="/saveInstitute/{ruc}", method=RequestMethod.GET)
	public String saveInstitute(@PathVariable String ruc, HttpServletRequest resquest){
		
		Institucions institucion = instituteClient.obtenerInstitucionPorRuc(ruc);
		resquest.getSession().setAttribute("institucion", institucion);
		
		return "redirect:/signupok";
	}

}
