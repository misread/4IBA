package by.gsu.epamlab.beans;

import by.gsu.epamlab.Constants;

public class PricePurchase extends Purchase {
	private Byn discount;
	
	public PricePurchase() { }
	
	public PricePurchase(String name, Byn price, int unitsNumber, Byn discount) {
		super(name, price, unitsNumber);
		setDiscount(discount);
	}
	
	public PricePurchase(String name, int priceInt, int unitsNumber, int discount) {
		super(name, priceInt, unitsNumber);
		setDiscount(discount);
	}

	public Byn getDiscount() {
		return discount;
	}

	public void setDiscount(Byn discount) {
		this.discount = discount;
	}
	
	public void setDiscount(int discountInt) {
		setDiscount(new Byn(discountInt));
	}
	
	public Byn getCost() {
		return super.getCost().sub(new Byn(discount).mul(getUnitsNumber()));
	}

	public String fieldsToString() {
		return super.fieldsToString() + Constants.DELIMETER + discount;
	}
}
