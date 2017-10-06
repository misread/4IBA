/**
 * @author Nadezhda Kokoulina
 */

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;

import by.gsu.epamlab.Calculator;

public class Runner {

	public static void main(String[] args) {
		Scanner sc = null;
		
		try {			
			sc = new Scanner(new FileReader("src/in.txt"));
			sc.useLocale(Locale.ENGLISH);
			
			Calculator<Double> calc = Calculator.getCalculator(sc);
					
			sc.nextLine();
			ArrayList<String> expression = new ArrayList<>();
						
			while (sc.hasNextLine()) {
				expression.add(sc.nextLine());
			}
			
			calc.calculate(expression);		
			
			double mem = calc.restore();
			System.out.println("memory: " + mem);
		}
		
		catch(FileNotFoundException e) {
			System.err.println("Input file is not found");
		}
		
		finally {
			if (sc != null) {
				sc.close();
			}
		}
	}

}