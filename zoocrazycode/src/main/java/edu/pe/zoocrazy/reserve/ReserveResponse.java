package edu.pe.zoocrazy.reserve;

import org.codehaus.jackson.annotate.JsonIgnoreProperties;
import org.codehaus.jackson.annotate.JsonProperty;


public class ReserveResponse {
	
	private Integer codigoReserva ;
	
	private String codigoUsuario = "1";
	
	private String fecha_reserva;
	
	private String asistentes;
	
	private String turno;
	
	private String preferencias;
	
	private String txtRepresentante;
	private String txtIntitucion;
	
	public ReserveResponse() {
	}
	
	public ReserveResponse(ReserveForm form) {
		this.codigoReserva = form.getCodigo()==null?0:Integer.parseInt(form.getCodigo());
		this.codigoUsuario = form.getCodigoUsuario();
		this.asistentes = form.getAsistentes();
		this.fecha_reserva = form.getFechaReserva();
		this.preferencias = form.getPreferencia();
		this.turno = form.getTurno();
	}

	public Integer getCodigoReserva() {
		return codigoReserva;
	}

	public void setCodigoReserva(Integer codigoReserva) {
		this.codigoReserva = codigoReserva;
	}

	public String getCodigoUsuario() {
		return codigoUsuario;
	}

	public void setCodigoUsuario(String codigoUsuario) {
		this.codigoUsuario = codigoUsuario;
	}

	public String getFecha_reserva() {
		return fecha_reserva;
	}

	public void setFecha_reserva(String fecha_reserva) {
		this.fecha_reserva = fecha_reserva;
	}

	public String getAsistentes() {
		return asistentes;
	}

	public void setAsistentes(String asistentes) {
		this.asistentes = asistentes;
	}

	public String getTurno() {
		return turno;
	}

	public void setTurno(String turno) {
		this.turno = turno;
	}

	public String getPreferencias() {
		return preferencias;
	}

	public void setPreferencias(String preferencias) {
		this.preferencias = preferencias;
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("ReserveResponse [codigoReserva=");
		builder.append(codigoReserva);
		builder.append(", codigoUsuario=");
		builder.append(codigoUsuario);
		builder.append(", fecha_reserva=");
		builder.append(fecha_reserva);
		builder.append(", asistentes=");
		builder.append(asistentes);
		builder.append(", turno=");
		builder.append(turno);
		builder.append(", preferencias=");
		builder.append(preferencias);
		builder.append("]");
		return builder.toString();
	}

	public String getTxtRepresentante() {
		return txtRepresentante;
	}

	public void setTxtRepresentante(String txtRepresentante) {
		this.txtRepresentante = txtRepresentante;
	}

	public String getTxtIntitucion() {
		return txtIntitucion;
	}

	public void setTxtIntitucion(String txtIntitucion) {
		this.txtIntitucion = txtIntitucion;
	}

	
}
