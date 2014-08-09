package edu.pe.zoocrazy.reserve;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;

import javax.servlet.http.HttpSession;
import javax.validation.Valid;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.http.converter.StringHttpMessageConverter;
import org.springframework.http.converter.json.MappingJacksonHttpMessageConverter;
import org.springframework.security.access.annotation.Secured;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.Errors;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import edu.pe.zoocrazy.soap.gestionarInstitucion.wsdl.Institucions;
import edu.pe.zoocrazy.support.web.MessageHelper;

@Secured("ROLE_USER")
@Controller
@RequestMapping(value="reserve")
public class ReserveController {
	
	private static final Logger logger = LoggerFactory.getLogger(ReserveController.class);
	
	private String URL = "http://localhost:30000/ReservasService.svc";
	public static final String REGISTER_REST_RESERVE = "/Reservas";	
	public static final String REGISTER_REST_ALL = "/Reservas";
	
	private final static String REGISTER_VIEW ="/register";
	private final static String REGISTER_SAVE ="/save";
	private final static String REGISTER_VIEW_ALL ="/all";
	
	
	@RequestMapping(value="/register", method=RequestMethod.GET)
	public String registerReserve(Model model, HttpSession session){
		ReserveForm form = new ReserveForm();
		Institucions instituto = (Institucions)session.getAttribute("institucion");
		if(instituto != null){
			form.setCodigoInstitucion(""+instituto.getCodigo());
			form.setTxtInstitucion(instituto.getNombre().getValue());
		}
		model.addAttribute(form);
		return "reservas/registrarReserva";
	}
	
	@RequestMapping(value = REGISTER_SAVE, method = RequestMethod.POST)
	public String saveReserve(@Valid @ModelAttribute ReserveForm reserveForm, Errors errors, RedirectAttributes ra) {
		if (errors.hasErrors()) {
			return "redirect:/reserve"+REGISTER_VIEW;
		}
		logger.debug("formulario=> "+reserveForm.toString());
		
		HttpHeaders headers = new HttpHeaders();
	    headers.setContentType(new MediaType("application","json"));
	    try{
	    	ReserveResponse reserveResponse = new ReserveResponse(reserveForm);
	    	HttpEntity<ReserveResponse> requestEntity = new HttpEntity<ReserveResponse>(reserveResponse, headers);
	    	
	    	RestTemplate restTemplate = new RestTemplate();
	    	restTemplate.getMessageConverters().add(new MappingJacksonHttpMessageConverter());
	    	restTemplate.getMessageConverters().add(new StringHttpMessageConverter());
	    	
	    	ResponseEntity<String> responseEntity =  restTemplate.exchange(URL+REGISTER_REST_RESERVE, HttpMethod.POST, requestEntity, String.class);
	    	String result = responseEntity.getBody();
	    	logger.debug(result);
	    	
	    	MessageHelper.addSuccessAttribute(ra, "reserve.success");
	    }catch(Exception e){
	    	MessageHelper.addErrorAttribute(ra, "reserve.nosuccess");
	    }
		
		return "redirect:/reserve"+REGISTER_VIEW;
	}
	
	
	@RequestMapping(value=REGISTER_VIEW_ALL, method=RequestMethod.GET)
	public String listReserve(Model model){
		logger.debug("try invoke method rest");		
		
		HttpHeaders requestHeaders = new HttpHeaders();
		requestHeaders.setAccept(Collections.singletonList(new MediaType("application","json")));
		HttpEntity<?> requestEntity = new HttpEntity<Object>(requestHeaders);
		RestTemplate restTemplate = new RestTemplate();
		
		restTemplate.getMessageConverters().add(new MappingJacksonHttpMessageConverter());
		ResponseEntity<ReserveResponse[]> responseEntity = restTemplate.exchange(URL+REGISTER_REST_ALL, HttpMethod.GET, requestEntity, ReserveResponse[].class);
		ReserveResponse[] reservas = responseEntity.getBody();
		List<ReserveResponse>reserves = Arrays.asList(reservas);
		logger.debug(""+reserves);
		
		model.addAttribute("reservas", reserves);
		return "/reservas/listar";
	}
	
	
}
