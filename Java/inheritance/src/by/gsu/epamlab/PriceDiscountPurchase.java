package by.gsu.epamlab;

import java.util.Scanner;

public class PriceDiscountPurchase extends Purchase {
	private Byn discount;

	public PriceDiscountPurchase(Byn discount) {
		this.discount = discount;
	}
	
	public PriceDiscountPurchase(Scanner sc) { 
		super(sc);
		this.discount = new Byn(sc.nextInt());
	}

	public Byn getDiscount() {
		return discount;
	}

	public void setDiscount(Byn discount) {
		this.discount = discount;
	}		
	
	public Byn getCost(){
		Byn cost = new Byn(getPrice()).sub(new Byn(discount)).mul(getNumber());
		return cost; 
	}	
		
	protected String fieldsToString() {
		return super.fieldsToString() + ";" + discount;
	}
}
