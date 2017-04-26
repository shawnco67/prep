namespace code.utility
{
  public delegate Output IMapFrom<Input, Output>(Input item);

  public delegate Output IReduce<Input, Output>(Output accumulator, Input item);
}