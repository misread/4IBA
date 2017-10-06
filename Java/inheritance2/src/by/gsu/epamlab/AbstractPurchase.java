package by.gsu.epamlab;

public abstract class AbstractPurchase implements Comparable<AbstractPurchase> {
	private final Commodity commodity;
	private int number;
		
	public AbstractPurchase(Commodity commodity, int number) {
		this.commodity = commodity;
		this.number = number;
	}

	public Commodity getCommodity() {
		return commodity;
	}
	
	public void setNumber(int number) {
		this.number = number;
	}

	public int getNumber() {
		return number;
	}
	
	public abstract Byn getFinalCost(int baseCost);
	
	public Byn getCost(){
		int baseCost = commodity.getPrice().getValue() * number;
		Byn finalCost = getFinalCost(baseCost);
		return finalCost.mul(1, RoundingMode.ROUND_RUBS);		
	}
		
	@Override
	public String toString() {
		return  fieldsToString() + ";" + getCost();
	}	
	
	protected String fieldsToString() {
		return commodity + ";" + number;
	}
	
	public int compareTo(AbstractPurchase purchase) {
		return purchase.getCost().compareTo(getCost());
	}
}
