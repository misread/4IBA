package by.gsu.epamlab.factories;

import by.gsu.epamlab.Constants;
import by.gsu.epamlab.beans.PriceDiscountPurchase;
import by.gsu.epamlab.beans.Purchase;
import by.gsu.epamlab.enums.Column;
import by.gsu.epamlab.exceptions.CsvLineException;

public class PurchasesFactory {
	private final static int PURCHASE_FIELDS_NUMBER = Purchase.class.
			getDeclaredFields().length;
	private final static int DISCOUNT_PURCHASE_FIELDS_NUMBER = PURCHASE_FIELDS_NUMBER +
			PriceDiscountPurchase.class.getDeclaredFields().length;
	
	public static Purchase getClassFromFactory(String csvLine) throws CsvLineException {
		String[] values = csvLine.split(Constants.DELIMETER);
		
		if ((values.length != PURCHASE_FIELDS_NUMBER) && (values.length !=
				DISCOUNT_PURCHASE_FIELDS_NUMBER)) {
			throw new CsvLineException(Constants.ERROR_WRONG_NUMBER, csvLine);
		}
		try {
			String name = values[Column.NAME.ordinal()];
			int priceInt = Integer.parseInt(values[Column.PRICE.ordinal()]);
			int units = Integer.parseInt(values[Column.UNITS_NUMBER.ordinal()]);
			
			if (values.length == PURCHASE_FIELDS_NUMBER) {
				return new Purchase(name, priceInt, units);
			} else {
				//possible problem when more than one field in the subclass
				int discountInt = Integer.parseInt(values[Column.DISCOUNT.ordinal()]);
				return new PriceDiscountPurchase(name, priceInt, units, discountInt);
			}
		} catch (NumberFormatException e) {
			throw new CsvLineException(Constants.ERROR_FORMAT_NUMBER, csvLine);
		} catch (RuntimeException e) {
			throw new CsvLineException(e, csvLine);
		}
	}
}
