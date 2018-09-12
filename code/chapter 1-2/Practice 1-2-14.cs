public bool Tequals(object x)
{
    /* 算法（第四版） 1.2.14 */
    if (this == x) return true;
    if (x == null) return false;
    if (this.GetType() != x.GetType()) return false;
    Transaction that = (Transaction)x;
    if (this.name != that.name) return false;
    if (this.dates != that.dates) return false;
    if (this.amounts != that.amounts) return false;
    return true;
}