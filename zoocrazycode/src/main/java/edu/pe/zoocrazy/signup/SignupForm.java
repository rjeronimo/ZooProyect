package edu.pe.zoocrazy.signup;

import org.hibernate.validator.constraints.Email;
import org.hibernate.validator.constraints.NotBlank;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.crypto.password.StandardPasswordEncoder;

import edu.pe.zoocrazy.account.Account;

public class SignupForm {
	
	private PasswordEncoder passwordEncoder = new StandardPasswordEncoder();

	private static final String NOT_BLANK_MESSAGE = "{notBlank.message}";
	private static final String EMAIL_MESSAGE = "{email.message}";

    @NotBlank(message = SignupForm.NOT_BLANK_MESSAGE)
	@Email(message = SignupForm.EMAIL_MESSAGE)
	private String email;

    @NotBlank(message = SignupForm.NOT_BLANK_MESSAGE)
	private String password;
    
    private String txtInstitucion;
    private String telefono;
    
    @NotBlank(message = SignupForm.NOT_BLANK_MESSAGE)
    private String idInstitucion;
    
    @NotBlank
    private String username;
    @NotBlank
    private String nombre;
    @NotBlank
    private String apellidos;
    
    @NotBlank
    private String dni;

    public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getTxtInstitucion() {
		return txtInstitucion;
	}

	public void setTxtInstitucion(String txtInstitucion) {
		this.txtInstitucion = txtInstitucion;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getApellidos() {
		return apellidos;
	}

	public void setApellidos(String apellidos) {
		this.apellidos = apellidos;
	}

	public String getDni() {
		return dni;
	}

	public void setDni(String dni) {
		this.dni = dni;
	}
	
	public String getTelefono() {
		return telefono;
	}
	
	public void setTelefono(String telefono) {
		this.telefono = telefono;
	}
	

	public Account createAccount() {
		Account account = new Account(getEmail(), getUsername(), passwordEncoder.encode(getPassword()), "ROLE_USER");
		account.setFirtsName(getNombre());
		account.setLastName(getApellidos());
		account.setDni(getDni());
		account.setPhone(getTelefono());
		account.setIdInstitucion(1);
        return account;
	}

	public String getIdInstitucion() {
		return idInstitucion;
	}

	public void setIdInstitucion(String idInstitucion) {
		this.idInstitucion = idInstitucion;
	}
}
