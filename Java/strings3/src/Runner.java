import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

import by.gsu.epamlab.DateTextCorrector;
import by.gsu.epamlab.MoneyTextCorrector;

public class Runner {

	public static void main(String[] args) {
		final String INPUT_FILE = "src\\in.txt";
		final String OUTPUT_FILE = "src\\out.txt";
		Scanner sc = null;
		FileWriter fileWriter;
		try {
			sc = new Scanner(new FileReader(INPUT_FILE));
			fileWriter = new FileWriter(OUTPUT_FILE);
			String newLineSymbol = "\n";
			String textLine;
			while (sc.hasNextLine()) {
				textLine = new MoneyTextCorrector().changeText(sc.nextLine());
				textLine = new DateTextCorrector().changeText(textLine);
				fileWriter.write(textLine + newLineSymbol);
			}
			fileWriter.close();
		} catch (FileNotFoundException e) {
			System.out.println("File " + INPUT_FILE + " is not found");
		} catch (IOException e) {
			System.out.println("File " + OUTPUT_FILE + " is not written");
		} finally {
			if (sc != null) {
				sc.close();
			}
		}
	}
}
