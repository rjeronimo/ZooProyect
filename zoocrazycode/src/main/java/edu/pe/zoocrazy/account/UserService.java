package edu.pe.zoocrazy.account;

import java.util.Collections;

import javax.annotation.PostConstruct;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;

public class UserService implements UserDetailsService {
	
	private static final Logger LOGGER = LoggerFactory.getLogger(UserService.class);
	
	@Autowired
	private AccountRepository accountRepository;
	
	@PostConstruct	
	protected void initialize() {
		accountRepository.save(new Account("user@hotmail.com", "user",  "demo", "ROLE_USER"));		
		accountRepository.save(new Account("admin@hotmail.com", "admin", "admin", "ROLE_ADMIN"));
	}
	
	@Override
	public UserDetails loadUserByUsername(String emailUser) throws UsernameNotFoundException {
		Account account = accountRepository.findByEmail(emailUser);
		if(account == null) {
			throw new UsernameNotFoundException("user not found");
		}
		return toUser(account);
	}
	
	private UserDetails toUser(Account account) {
		return new edu.pe.zoocrazy.account.User(account);
	}
	
	public void signin(Account account) {
		SecurityContextHolder.getContext().setAuthentication(authenticate(account));
		
	}
	
	private Authentication authenticate(Account account) {
		UserDetails user = toUser(account);
		return new UsernamePasswordAuthenticationToken(user, user.getPassword(), user.getAuthorities());		
	}
	
	private User createUser(Account account) {
		return new User(account.getUserName(), account.getPassword(), Collections.singleton(createAuthority(account)));
	}

	private GrantedAuthority createAuthority(Account account) {
		return new SimpleGrantedAuthority(account.getRole());
	}

}
