package by.gsu.epamlab.beans;

import by.gsu.epamlab.Constants;

public class Purchase {
	private String name;
	private Byn price;
	private int unitsNumber;
	
	public Purchase() {	}

	public Purchase(String name, Byn price, int unitsNumber) {
		setNameAndNumber(name, unitsNumber);
		setPrice(price);
	}
	
	public Purchase(String name, int priceInt, int unitsNumber) {
		setNameAndNumber(name, unitsNumber);
		setPrice(priceInt);
	}
	
	private void setNameAndNumber(String name, int unitsNumber) {
		setName(name);
		setUnitsNumber(unitsNumber);
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
	
	public void setPrice(int priceInt) {
		setPrice(new Byn(priceInt));
	}

	public int getUnitsNumber() {
		return unitsNumber;
	}

	public void setUnitsNumber(int unitsNumber) {
		this.unitsNumber = unitsNumber;
	}
	
	public Byn getCost() {
		return new Byn(price).mul(unitsNumber);
	}
	
	protected String fieldsToString() {
		return name + Constants.DELIMETER + price + Constants.DELIMETER + unitsNumber;
	}
	
	public String toString() {
		return fieldsToString() + Constants.DELIMETER + getCost();
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		return result * prime + getName().hashCode() + getPrice().hashCode();
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		Purchase other = (Purchase)obj;
		if (!getName().equals(other.getName()))
			return false;
		if (!getPrice().equals(other.getPrice()))
			return false;
		return true;
	}
}
