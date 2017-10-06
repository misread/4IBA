import java.util.Arrays;

import by.gsu.epamlab.AbstractPurchase;
import by.gsu.epamlab.Byn;
import by.gsu.epamlab.Commodity;
import by.gsu.epamlab.PercentDiscountPurchase;
import by.gsu.epamlab.PriceDiscountPurchase;
import by.gsu.epamlab.TransportExpensesPurchase;

public class Runner { 
	final static Commodity milk = new Commodity("Milk", 250);
	
	public static void main(String[] args) {		
		AbstractPurchase[] purchases = {
				new PriceDiscountPurchase(milk, 2, 0),
				new PriceDiscountPurchase(milk, 7, 150),
				new PercentDiscountPurchase(milk, 16, 10.61),
				new PercentDiscountPurchase(milk, 8, 14.2),
				new TransportExpensesPurchase(milk, 14, 483),
				new TransportExpensesPurchase(milk, 2, 320)
		};
		
		printPurchases(purchases);
												
		Arrays.sort(purchases);
		
		System.out.println("Sorted:");
		printPurchases(purchases);
		
		System.out.println("Minimum cost = " + purchases[purchases.length-1].getCost());
		
		binarySearchN(purchases, 5, 00);
	}
	
	private static void printPurchases(AbstractPurchase[] purchases) {
		if (purchases.length > 0) {
			for (AbstractPurchase purchase : purchases) {
				System.out.println(purchase);
			}
		}
		else {
			System.out.println("There are no purchases");	
		}
	}
	
	private static void binarySearchN(AbstractPurchase[] purchases, int rubs, int coins) {
		final Byn costSearch = new Byn(rubs, coins);
		
		AbstractPurchase purchase = new PriceDiscountPurchase(milk,0,0) {
			@Override
			public Byn getCost() {
				return new Byn(costSearch.getValue());
			}
		};
		
		int index = Arrays.binarySearch(purchases, purchase);
				
		System.out.print("Purchase with cost equaled to " + costSearch);		
		if (index >= 0) {
			System.out.println(": " + purchases[index]);
		}
		else {
			System.out.println(" is not found");
		}
	}
}
