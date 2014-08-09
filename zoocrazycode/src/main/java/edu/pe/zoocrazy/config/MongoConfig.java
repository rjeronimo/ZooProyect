package edu.pe.zoocrazy.config;

import java.net.UnknownHostException;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.FilterType;
import org.springframework.data.mongodb.MongoDbFactory;
import org.springframework.data.mongodb.core.MongoTemplate;
import org.springframework.data.mongodb.core.SimpleMongoDbFactory;
import org.springframework.data.mongodb.core.convert.DefaultMongoTypeMapper;
import org.springframework.data.mongodb.core.convert.MappingMongoConverter;
import org.springframework.data.mongodb.core.convert.MongoTypeMapper;
import org.springframework.data.mongodb.core.mapping.MongoMappingContext;
import org.springframework.data.mongodb.repository.config.EnableMongoRepositories;

import com.mongodb.Mongo;

import edu.pe.zoocrazy.account.AccountRepository;

@EnableMongoRepositories(basePackages = "edu.pe.zoocrazy", 
	includeFilters = @ComponentScan.Filter(value = { AccountRepository.class }, type = FilterType.ASSIGNABLE_TYPE))
class MongoConfig {

	 @Value("${mongo.db.name}")
	 private String dbname;
	 @Value("${mongo.host.name}")
	 private String host;
	 @Value("${mongo.host.port}")
	 private int port;

	@Bean
	public MongoDbFactory mongoDbFactory() throws UnknownHostException {
		System.out.println("mongoDBFactory");
		return new SimpleMongoDbFactory(mongo(), dbname);
	}

	 public @Bean Mongo mongo() throws UnknownHostException {
		 System.out.println(host + "  "+ port + "  "+ dbname);
		 return new Mongo(host, port);
	 }

	@Bean
	public MongoTemplate mongoTemplate() throws UnknownHostException {
		System.out.println("mongoTemplate");
		MongoTemplate template = new MongoTemplate(mongoDbFactory(),
				mongoConverter());
		return template;
	}

	@Bean
	public MongoTypeMapper mongoTypeMapper() {
		return new DefaultMongoTypeMapper(null);
	}

	@Bean
	public MongoMappingContext mongoMappingContext() {
		return new MongoMappingContext();
	}

	@Bean
	public MappingMongoConverter mongoConverter() throws UnknownHostException {
		MappingMongoConverter converter = new MappingMongoConverter(
				mongoDbFactory(), mongoMappingContext());
		converter.setTypeMapper(mongoTypeMapper());
		return converter;
	}
}
