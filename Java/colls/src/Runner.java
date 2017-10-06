import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.EnumMap;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;

import by.gsu.epamlab.beans.Byn;
import by.gsu.epamlab.beans.PricePurchase;
import by.gsu.epamlab.beans.Purchase;
import by.gsu.epamlab.enums.Days;
import by.gsu.epamlab.factories.PurchasesFactory;
import by.gsu.epamlab.interfaces.EntryChecker;

public class Runner {

	public static void main(String[] args) {
		Scanner sc = null;
		String filePath = "src/in.csv";
		
		try {
			sc = new Scanner(new FileReader(filePath));
			sc.useLocale(Locale.ENGLISH);
						
			Map<Purchase, Days> purchasesLastDay = new HashMap<Purchase, Days>();
			Map<Purchase, Days> purchasesFirstDay = new HashMap<Purchase, Days>();
			List<PricePurchase> pricePurchases = new ArrayList<PricePurchase>();
			Map<Days, List<Purchase>> days = new EnumMap<Days, List<Purchase>>(Days.class);
						
			while (sc.hasNext()) {
				Purchase purchase = PurchasesFactory.getClassFromFactory(sc.nextLine());
				Days day = Days.valueOf(sc.nextLine());
				List<Purchase> p = days.get(day);
				
				if (!purchasesFirstDay.containsKey(purchase)) {
					purchasesFirstDay.put(purchase, day);
				}
				purchasesLastDay.put(purchase, day);
				
				if (purchase instanceof PricePurchase) {
					pricePurchases.add((PricePurchase)purchase);
				}
				
				if (p == null) {
					days.put(day, p = new ArrayList<Purchase>());
				}
				p.add(purchase);					
			}
						
			printMap(purchasesFirstDay, "First purchase map:");
			printMap(purchasesLastDay, "Last purchase map:");
			printMap(days, "Enumerated map:");
			
			Purchase bread = new Purchase("bread", 155, 1);			
			findElement(purchasesFirstDay, bread, "The first weekday for bread with price 1.55: ");
			findElement(purchasesLastDay, bread, "The last weekday for bread with price 1.55: ");
			
			bread.setPrice(170);
			findElement(purchasesFirstDay, bread, "The first weekday for bread with price 1.70: ");
			
			removeEntries(purchasesFirstDay, new EntryChecker<Purchase, Days>() {
				@Override
				public boolean check(Entry<Purchase, Days> entry) {
					return entry.getKey().getName().equals("meat");
				}
			});
			removeEntries(purchasesLastDay, new EntryChecker<Purchase, Days>() {
				@Override
				public boolean check(Entry<Purchase, Days> entry) {
					return entry.getValue() == Days.FRIDAY;
				}
			});
			
			printMap(purchasesFirstDay, "First purchase map after removal:");
			printMap(purchasesLastDay, "Last purchase map after removal:");
			
			totalCost(pricePurchases, "Total cost of PricePurchases: ");
						
			final Enumeration<Days> daysEnum = Collections.enumeration(days.keySet());
			while (daysEnum.hasMoreElements()) {
			for (List<Purchase> entry : days.values()) {
					totalCost(entry, "Total cost on " + daysEnum.nextElement()  + ": ");
				}
			}
						
			findElement(days, Days.MONDAY, "All purchases on MONDAY: ");	
			
			removeEntries(days, new EntryChecker<Days, List<Purchase>>() {
				@Override
				public boolean check(Entry<Days, List<Purchase>> entry) {
					return entry.getValue().contains(new Purchase("milk", 131, 0));
				}
			});
			
			printMap(days, "Enumerated map after removal:");
		}
		catch (FileNotFoundException e) {
			System.err.println("File " + filePath + " is not found");
		}
		finally {
			if (sc != null) {
				sc.close();
			}
		}
	}	
	
	private static <K, V> void printMap(Map<K, V> map, String header) {
		System.out.println("\t" + header);
		for (Map.Entry<K, V> entry : map.entrySet()) {
			System.out.println(entry.getKey() + ": " + entry.getValue());
		}	
	}
	
	private static <K, V> void findElement(Map<K, V> map, K key, String header) {
		System.out.print(header);			
		System.out.println(map.get(key));				
	}
		
	private static <K, V> void removeEntries(Map<K, V> map, EntryChecker<K, V> checker) {
		boolean found = false;
		for (Iterator<Entry<K, V>> it = map.entrySet().iterator(); 
				it.hasNext();) {
			Map.Entry<K, V> entry = it.next();
			if (checker.check(entry)) {
				System.out.println("Removed: " + entry.toString());
				it.remove();
				found = true;
			}			
		}
		if (!found) {
			System.out.println("No data to remove found");
		}
	}
	
	private static void totalCost(List<? extends Purchase> list, String header) {
		Byn total = new Byn();
		for (Purchase purchase : list) {
			total.add(purchase.getCost());
		}
		System.out.println(header + total);
	}
}
