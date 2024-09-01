using System;
using System.Collections;

public class SalesPerson
{
    //Creating private variables
	private string _name;
	private string _title;
	private List<double> _sales;

    //Creating the getter and setters for the variables
	public string Name
	{
		get { return _name; }
		set
		{
			_name = value;
		}
	}
    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
        }
    }
    public List<double> Sales
    {
        get { return _sales; }
        set
        {
            _sales = value;
        }
    }
    //Create Constructor for Class
    public SalesPerson()
	{
        _name = "";
        _title = "";
        _sales = new List<double>();
	}
    public SalesPerson(string name, string title, List<double> sales)
    {
        _name = name;
        _title = title;
        _sales = sales;
    }

    public IEnumerable<double> IterSales()
    {
        foreach (var sale in _sales)
        {
            yield return sale;
        }
    }
}
