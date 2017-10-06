package by.gsu.epamlab;

import java.util.Scanner;

public class PurchasesFactory {
	private static enum PurchaseType {
		GENERAL_PURCHASE {
			Purchase getPurchase(Scanner sc) {
				return new Purchase(sc);
			}
		},
		PRICE_DISCOUNT_PURCHASE {
			PriceDiscountPurchase getPurchase(Scanner sc) {
				return new PriceDiscountPurchase(sc);
			}
		},
		PERCENT_DISCOUNT_PURCHASE {
			PercentDiscountPurchase getPurchase(Scanner sc) {
				return new PercentDiscountPurchase(sc);
			}
		};
		abstract Purchase getPurchase(Scanner sc);
	}
	
	public static Purchase getPurchaseFromFactory(Scanner sc) {
		PurchaseType type = PurchaseType.valueOf(sc.next());		
		return type.getPurchase(sc);
	}
}
