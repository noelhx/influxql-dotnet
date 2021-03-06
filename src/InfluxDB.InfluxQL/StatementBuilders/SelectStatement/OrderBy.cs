using InfluxDB.InfluxQL.Syntax.Clauses;
using InfluxDB.InfluxQL.Syntax.Statements;

namespace InfluxDB.InfluxQL.StatementBuilders.SelectStatement
{
    public class OrderBy<TValues>
    {
        internal OrderBy(SingleSeriesSelectStatement<TValues> statement)
        {
            Statement = new SingleSeriesSelectStatement<TValues>(statement.Select, statement.From, statement.Where, statement.GroupBy, statement.Fill, new OrderByClause());
        }

        public SingleSeriesSelectStatement<TValues> Statement { get; }

        public Limit<TValues> Limit(int n) => new Limit<TValues>(Statement, n);

        public Offset<TValues> Offset(int n) => new Offset<TValues>(Statement, n);

        public override string ToString() => Statement.Text;

        public static implicit operator SingleSeriesSelectStatement<TValues>(OrderBy<TValues> builder) => builder.Statement;
    }

    public class OrderBy<TValues, TGroupBy>
    {
        internal OrderBy(MultiSeriesSelectStatement<TValues, TGroupBy> statement)
        {
            Statement = new MultiSeriesSelectStatement<TValues, TGroupBy>(statement.Select, statement.From, statement.Where, statement.GroupBy, statement.Fill, new OrderByClause());
        }

        public MultiSeriesSelectStatement<TValues, TGroupBy> Statement { get; }

        public Limit<TValues, TGroupBy> Limit(int n) => new Limit<TValues, TGroupBy>(Statement, n);

        public Offset<TValues, TGroupBy> Offset(int n) => new Offset<TValues, TGroupBy>(Statement, n);

        public SLimit<TValues, TGroupBy> SLimit(int n) => new SLimit<TValues, TGroupBy>(Statement, n);

        public SOffset<TValues, TGroupBy> SOffset(int n) => new SOffset<TValues, TGroupBy>(Statement, n);

        public override string ToString() => Statement.Text;

        public static implicit operator MultiSeriesSelectStatement<TValues, TGroupBy>(OrderBy<TValues, TGroupBy> builder) => builder.Statement;
    }
}