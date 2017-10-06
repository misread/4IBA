package by.gsu.epamlab;

public class PercentDiscountPurchase extends AbstractPurchase {
	private static final int UNITS = 15;
	private double discount;
	
	public PercentDiscountPurchase(Commodity commodity, int number, double discount) { 
		super(commodity, number);
		this.discount = discount;
	}

	public double getMegaDiscount() {
		return discount;
	}

	public void setMegaDiscount(double discount) {
		this.discount = discount;
	}
		
	public Byn getFinalCost(int baseCost){	
		Byn cost = new Byn(baseCost);
		if (getNumber() > UNITS) {
			cost.setValue((int)((cost.getValue()) * (1 - discount / 100)));
		}		
		return cost;		
	}	
	
	protected String fieldsToString() {
		return super.fieldsToString() + ";" + discount;
	}
}
