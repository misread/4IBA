package by.gsu.epamlab.exceptions;

import by.gsu.epamlab.Constants;
import by.gsu.epamlab.enums.NumField;

//@SuppressWarnings("serial")
public class NegativeArgumentException extends NonpositiveArgumentException {
	
	public NegativeArgumentException() {
		
	}
	
	public NegativeArgumentException(int value, NumField field) {
		super(value, field);
	}
	
	public String getHead() {
		return Constants.ERROR_EXCEPTION_NEGATIVE_HEAD;
	}
}
