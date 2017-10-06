package by.gsu.epamlab;

import java.util.Scanner;

public class PercentDiscountPurchase extends Purchase {
	private static final int UNITS = 11;
	private double discount;

	public PercentDiscountPurchase(double discount) {
		this.discount = discount;
	}
	
	public PercentDiscountPurchase(Scanner sc) {
		super(sc);
		this.discount = sc.nextDouble();
	}

	public double getPercentDiscount() {
		return discount;
	}

	public void setPercentDiscount(double discount) {
		this.discount = discount;
	}
		
	public Byn getCost(){
		Byn cost = new Byn(super.getCost());
		
		if (super.getNumber() > UNITS) {
			cost.mul((int)Math.round(1 - discount / 100)); 
		}
		
		return cost;
	}
	
	protected String fieldsToString() {
		return super.fieldsToString() + ";" + discount;
	}
}
