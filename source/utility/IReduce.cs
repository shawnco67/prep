namespace code.utility
{
  public delegate Output IReduce<Input, Output>(Output accumulator, Input item);
}