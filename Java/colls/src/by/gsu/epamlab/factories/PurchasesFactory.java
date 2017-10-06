package by.gsu.epamlab.factories;

import by.gsu.epamlab.Constants;
import by.gsu.epamlab.beans.PricePurchase;
import by.gsu.epamlab.beans.Purchase;

public class PurchasesFactory {
	private final static int PURCHASES_FIELDS_NUMBER = 
			Purchase.class.getDeclaredFields().length;
	
	public static Purchase getClassFromFactory(String csvLine) throws ArrayIndexOutOfBoundsException {
		String[] values = csvLine.split(Constants.DELIMETER);
		
		try {
			String name = values[0];
			int priceInt = Integer.parseInt(values[1]);
			int unitsNumber = Integer.parseInt(values[2]);
			
			if (values.length == PURCHASES_FIELDS_NUMBER) {
				return new Purchase(name, priceInt, unitsNumber);
			}
			else {
				int discountInt = Integer.parseInt(values[3]);
				return new PricePurchase(name, priceInt, unitsNumber, discountInt);
			}
		}
		catch (ArrayIndexOutOfBoundsException e) {
			throw new ArrayIndexOutOfBoundsException(e.getMessage());
		}
	}
}
