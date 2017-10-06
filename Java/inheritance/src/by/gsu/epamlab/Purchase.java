package by.gsu.epamlab;

import java.util.Scanner;

public class Purchase{
	private String name; // commodity name
	private Byn price; // BYN
	private int number; // number of purchased units
	
	public Purchase() {	}	

	public Purchase(String name, Byn price, int number) {
		this.name = name;
		this.price = price;
		this.number = number;
	}

	public Purchase(Scanner sc) {
		this(sc.next(), new Byn(sc.nextInt()), sc.nextInt());
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Byn getPrice() {
		return price;
	}

	public void setPrice(Byn price) {
		this.price = price;
	}

	public int getNumber() {
		return number;
	}

	public void setNumber(int number) {
		this.number = number;
	}
	
	public Byn getCost(){
		Byn cost = new Byn(price).mul(number);
		return cost; 
	}

	@Override
	public String toString() {
		return fieldsToString() + ";" + getCost();
	}
	
	protected String fieldsToString() {
		return name + ";" + price + ";" + number;
	}
	
	public boolean equals(Object obj){
        if (!(obj instanceof Purchase)) {
        	return false;
        }    
        return name.equals(((Purchase) obj).getName()) && price.equals(((Purchase)obj).getPrice());
    }
}
