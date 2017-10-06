package by.gsu.epamlab;

public class TransportExpensesPurchase extends AbstractPurchase {
	private Byn transport;
		
	public TransportExpensesPurchase(Commodity commodity, int number, int transport) { 
		super(commodity, number);
		this.transport =  new Byn(transport);
	}

	public Byn getTransportExpenses() {
		return transport;
	}

	public void setTransportExpenses(int transport) {
		this.transport = new Byn(transport);
	}		
	
	public Byn getFinalCost(int baseCost){
		Byn cost = new Byn(baseCost + transport.getValue());
		return cost; 
	}	
	
	protected String fieldsToString() {
		return super.fieldsToString() + ";" + transport;
	}
}
