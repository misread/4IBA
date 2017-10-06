package by.gsu.epamlab.enums;

public enum Days {
	MONDAY("MONDAY"), TUESDAY("TUESDAY"), WEDNESDAY("WEDNESDAY"),
	THURSDAY("THURSDAY"), FRIDAY("FRIDAY"), SATURDAY("SATURDAY"),
	SUNDAY("SUNDAY");
	
	private final String name;
	
	private Days(final String name) {
		this.name = name;
	}
	
	public String toString() {
		return name;
	}
}
