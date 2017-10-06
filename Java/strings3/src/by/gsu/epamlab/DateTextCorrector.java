package by.gsu.epamlab;

import java.text.DateFormat;
import java.text.ParseException;
import java.util.Date;
import java.util.Locale;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DateTextCorrector extends TextCorrector {
	private static final String NUMBER = "\\d{1,2}";
	private static final String DELIMETER = "((/)|(-)|(\\.))";
	private static final String YEAR = "((\\d{4})|(\\d{2}))";
	private static final String DATE = NUMBER + DELIMETER + NUMBER + DELIMETER + YEAR;
	
	public DateTextCorrector() {
		super(Pattern.compile(DATE));
	}
	
	protected String editText(String editableText) {
		Matcher matcher = PATTERN.matcher(editableText);
		if (matcher.find()) {
			String original = matcher.group();
			String temp = original;
			String defaultDelimeter = ".";
			String usedDelimeter = matcher.group(1);
			int groupYear = matcher.groupCount() - 2;
			String year = matcher.group(groupYear);
			DateFormat df = DateFormat.getDateInstance();
			Date date;
			
			try {
				if (year.length() == 2) {
					year = 20 + year;
					temp = temp.substring(0, temp.length() - 2) + year;
				}
				if (!defaultDelimeter.equals(usedDelimeter)) {
					temp = temp.replace(usedDelimeter, defaultDelimeter);
				}
				date = df.parse(temp);
				df = DateFormat.getDateInstance(DateFormat.LONG, Locale.ENGLISH);
				temp = df.format(date);
			} catch (ParseException e) {
				e.printStackTrace();
			}
			editableText = editableText.replace(original, temp);
		}
		return editableText;
	}
}
