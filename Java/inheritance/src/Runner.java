/**
* @author Nadezhda Kokoulina
*/

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Locale;
import java.util.Scanner;

import by.gsu.epamlab.Byn;
import by.gsu.epamlab.Purchase;
import by.gsu.epamlab.PurchasesFactory;

public class Runner {

	public static void main(String[] args) {
		Scanner sc = null;
		
		try {
			sc = new Scanner(new FileReader("src/in.txt"));
			sc.useLocale(Locale.ENGLISH);		
			
			final int PURCHASES_NUMBER = 6;
			Purchase[] purchases = new Purchase[PURCHASES_NUMBER];
			
			Byn maxCost = new Byn();
			Purchase max = new Purchase();
			boolean areEqual = true;
									
			for (int i = 0; i < purchases.length; i++) {
				purchases[i] = PurchasesFactory.getPurchaseFromFactory(sc);	
				
				System.out.println(purchases[i]);
				
				Byn cost = purchases[i].getCost();
				
				if (cost.compareTo(maxCost) > 0) {
					maxCost = cost;
					max = purchases[i];
				}
				
				if (areEqual) {
					areEqual = purchases[i].equals(purchases[0]);
				}				
			}
			
			System.out.println("The purchase with maximum cost: " + max);	
			
			if (areEqual) {
				System.out.println("Purchases are equal");
			}	
			else {
				System.out.println("Purchases are not equal");
			}
		}
		
		catch (FileNotFoundException e) {
			System.err.println("Input file is not found");
		}
		
		finally {
			if (sc != null) {
				sc.close();
			}
		}		
	}	
}
