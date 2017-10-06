import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Locale;
import java.util.Scanner;

public class Runner {

	public static void main(String[] args) {
		Scanner sc = null;
		
		try {			
			final String INPUT_CSV = "src/in.csv";	
			final String BEFORE_SIGN = " ";
			final String AFTER_SIGN = " ";
			final String PLUS = BEFORE_SIGN + "+" + AFTER_SIGN;
			final String MINUS = BEFORE_SIGN + "-" + AFTER_SIGN;
			final String DELIMETER = ";";
			final String RESULT_HEAD = "result(";
			final String RESULT_TAIL = ") = ";
			final String ERROR_LINES = "error-lines = ";
			
			sc = new Scanner(new FileReader(INPUT_CSV));			
			sc.useLocale(Locale.ENGLISH);
						
			StringBuilder strResult = new StringBuilder();
			double sum = 0;
			int errorLine = 0;			
					
			while (sc.hasNextLine()) {	
				String[] words = sc.nextLine().split(DELIMETER);	
				try {
					int index = Integer.parseInt(words[0].trim());
					double x = Double.parseDouble(words[index]);
					sum += x;
					strResult.append(x < 0 ? MINUS : PLUS).append(Math.abs(x));
				}
				catch (NumberFormatException | ArrayIndexOutOfBoundsException e) { 
					errorLine++;
				}					
			}
			
			if (strResult.length() > 0) {
				final int SIGN_LENGTH = MINUS.length();
				final char CHAR_MINUS = '-';
				final int SIGN_POS = MINUS.indexOf(CHAR_MINUS);
				
				char symbol = strResult.charAt(SIGN_POS);
				strResult.delete(0, SIGN_LENGTH);
				
				if (symbol == CHAR_MINUS) {
					strResult.insert(0, CHAR_MINUS);
				}
			}
			
			System.out.println(RESULT_HEAD + strResult + RESULT_TAIL + sum);
			System.out.println(ERROR_LINES + errorLine);
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
