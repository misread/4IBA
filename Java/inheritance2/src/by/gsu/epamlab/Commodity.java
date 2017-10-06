package by.gsu.epamlab;

public final class Commodity {
	private final String name;
	private final Byn price;	
	
	public Commodity(String name, int price) {
		this.name = name;
		this.price = new Byn(price);
	}

	public String getName() {
		return name;
	}

	public Byn getPrice() {
		return price;
	}
	
	@Override
	public String toString() {
		return name + ";" + price;
	}	
}
