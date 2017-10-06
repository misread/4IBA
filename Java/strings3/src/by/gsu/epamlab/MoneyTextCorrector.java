package by.gsu.epamlab;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class MoneyTextCorrector extends TextCorrector {
	private static final String NUMBER = "((\\d{1,3})(\\s+\\d{3})*)";
	private static final String CURRENCY = "((belarusian roubles)|(blr))";
	private static final String MONEY = NUMBER + "(\\s+)" + CURRENCY;
	
	public MoneyTextCorrector() {
		super (Pattern.compile(MONEY));
	}
	
	protected String editText (String editableText) {
		Matcher matcher = PATTERN.matcher(editableText);
		if (matcher.find()) {
			int numGroup = 1;
			int currencyGroup = matcher.groupCount() - 2;
			String money = matcher.group(numGroup);
			String spaceSign = " ";
			String currency = matcher.group(currencyGroup);
			money = money.replace(spaceSign, "");
			editableText = money + spaceSign + currency;
		}
		return editableText;
	}
}
