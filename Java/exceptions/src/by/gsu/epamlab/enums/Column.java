package by.gsu.epamlab.enums;

import java.util.Arrays;
import java.util.Formatter;

import by.gsu.epamlab.Constants;
import by.gsu.epamlab.beans.Byn;

public enum Column {
	NAME("name", -10), PRICE("price", 10),
	UNITS_NUMBER("number", 9), DISCOUNT("discount", 10),
	COST("cost", 12);
	
	private final String name;
	private final int colLength;
	
	Column(final String name, final int colLength) {
		this.name = name;
		this.colLength = colLength;
	}

	public String getName() {
		return name;
	}

	public int getColLength() {
		return colLength;
	}
	
	public String getValueFormat() {
		return "%" + colLength + "s";
	}
	
	public String getHeaderFormat() {
		return "%" + colLength + "s";
	}
	
	public static String getHeader() {
		Formatter f = new Formatter();
		for (Column column : values()) {
			f.format(column.getHeaderFormat(), column.getName());
		}
		return f.toString();
	}
	
	private static int getTotalColLength(int colNumber) {
		int sum = 0;
		for (int i = 0; i < colNumber; i++) {
			sum += Math.abs(values()[i].getColLength());
		}
		return sum;
	}
	
	public final static String HORIZONTAL_LINE;
	static {
		final char LINE_CHAR = '-';
		char[] hLine = new char[getTotalColLength(values().length)];
		Arrays.fill(hLine, LINE_CHAR);
		HORIZONTAL_LINE = new String(hLine);
	}
	
	public static String getRow(String csvPurchase) {
		Formatter f = new Formatter();
		String[] values = csvPurchase.split(Constants.DELIMETER);
		
		//a few tricks below
		//1. save cost i.e. last value
		String strCost = values[values.length - 1];
		Column[] columnValues = Column.values();
		
		//2. replace last value for null discount
		values[values.length - 1] = Constants.NULL_DISCOUNT;
		
		//3. push input values
		for (int i = 0; i < columnValues.length - 1; i++) {
			f.format(columnValues[i].getValueFormat(), values[i]);
		}
		
		//4. push cost
		f.format(COST.getValueFormat(), strCost);
		
		return f.toString();
	}
	
	public static String getFooter(Byn totalCost) {
		Formatter f = new Formatter();
		final String TOTAL_COST = "Total cost";
		int numSpaces = - TOTAL_COST.length() + getTotalColLength(values().length);
		f.format(TOTAL_COST + "%" + numSpaces + "s", totalCost);
		return f.toString();
	}
}
