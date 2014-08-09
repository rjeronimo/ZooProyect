package edu.pe.zoocrazy.reserve;

import org.hibernate.validator.constraints.NotEmpty;


public class ReserveForm {
	
	private String codigo ;
	private String codigoUsuario = "2";	
	
	private String codigoInstitucion;
	private String txtInstitucion = "San Andres";
	private String txtRepresentante;
	@NotEmpty(message="{notBlank.message}")
	private String asistentes;
	@NotEmpty(message="{notBlank.message}")
	private String fechaReserva;
	@NotEmpty(message="{notBlank.message}")
	private String turno;
	private String preferencia;
	
	public ReserveForm() {
	}
	
	public String getCodigo() {
		return codigo;
	}
	public void setCodigo(String codigo) {
		this.codigo = codigo;
	}
	public String getCodigoUsuario() {
		return codigoUsuario;
	}
	public void setCodigoUsuario(String codigoUsuario) {
		this.codigoUsuario = codigoUsuario;
	}
	public String getAsistentes() {
		return asistentes;
	}
	public void setAsistentes(String asistentes) {
		this.asistentes = asistentes;
	}
	public String getFechaReserva() {
		return fechaReserva;
	}
	public void setFechaReserva(String fechaReserva) {
		this.fechaReserva = fechaReserva;
	}
	public String getTurno() {
		return turno;
	}
	public void setTurno(String turno) {
		this.turno = turno;
	}
	public String getPreferencia() {
		return preferencia;
	}
	public void setPreferencia(String preferencia) {
		this.preferencia = preferencia;
	}
	public String getTxtInstitucion() {
		return txtInstitucion;
	}
	public void setTxtInstitucion(String txtInstitucion) {
		this.txtInstitucion = txtInstitucion;
	}
	public String getTxtRepresentante() {
		return txtRepresentante;
	}
	public void setTxtRepresentante(String txtRepresentante) {
		this.txtRepresentante = txtRepresentante;
	}

	@Override
	public String toString() {
		return "ReserveForm [codigo=" + codigo + ", codigoUsuario="
				+ codigoUsuario + ", txtInstitucion=" + txtInstitucion
				+ ", txtRepresentante=" + txtRepresentante + ", asistentes="
				+ asistentes + ", fechaReserva=" + fechaReserva + ", turno="
				+ turno + ", preferencia=" + preferencia + "]";
	}

	public String getCodigoInstitucion() {
		return codigoInstitucion;
	}

	public void setCodigoInstitucion(String codigoInstitucion) {
		this.codigoInstitucion = codigoInstitucion;
	}

}
