using System.Collections;
using UnityEngine;

public class GamePieces : MonoBehaviour
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set { if (IsMovable()) {
                x = value;
            } 
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (IsMovable())
            {
                y = value;
            }
        }
    }

    private Grids.PieceType type;

    public Grids.PieceType Type
    {
        get { return type; } 
    }

    private Grids grid;
    public Grids GridRef
    {
        get { return grid; }
    }

    private MovablePiece movableComponent;
    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
    }
    private ColorPiece colorComponent;
    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }
    private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent
    {
        get { return clearableComponent; }
    }
    void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearablePiece>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int _x,int _y, Grids _grid, Grids.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }
     void OnMouseEnter()
    {
        grid.EnteredPiece(this);
    }
    void OnMouseDown()
    {
        grid.PressPiece(this);
    }
    void OnMouseUp()
    {
        grid.ReleasePiece();
    }

    public bool IsMovable() 
    {
        return movableComponent != null; 
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }
    public bool IsClearable()
    {
        return clearableComponent != null;
    }

}
