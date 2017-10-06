package by.gsu.epamlab;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public abstract class TextCorrector {
	protected final Pattern PATTERN;
	
	protected TextCorrector(Pattern pattern) {
		PATTERN = pattern;
	}
	
	public String changeText(String text) {
		Matcher matcher = PATTERN.matcher(text);
		String editableText;
		String editedText;
		while (matcher.find()) {
			editableText = matcher.group();
			editedText = editText(editableText);
			text = text.replace(editableText, editedText);
		}
		return text;
	}
	
	protected abstract String editText(String editableText);
}
