package edu.pe.zoocrazy.account;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.repository.PagingAndSortingRepository;

public interface AccountRepository extends MongoRepository<Account, String>, 
		PagingAndSortingRepository<Account, String>{
	
	public Account findByEmail(String email);
	
	public Account findByUserName(String userName);
	
	public Account findByDni(String dni);
	
}
