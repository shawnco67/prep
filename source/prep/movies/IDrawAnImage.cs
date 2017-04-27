using System;
using System.Collections.Generic;
using System.Threading;
using code.utility;

namespace code.prep.movies
{
  public interface IDrawAnImage
  {
    void draw(IRenderToADrawingSurface surface); 
  }

  public interface IRenderToADrawingSurface
  {
    void render(IRepresentAGlyph glyph);
  }

  public interface IRepresentAGlyph
  {
  }


  public class BasicImage : IDrawAnImage
  {
    public void draw(IRenderToADrawingSurface surface)
    {
      //complex image prep
    }
  }

  public delegate bool IConstrainAnOperation();

  public class WatermarkedImage : IDrawAnImage
  {
    IDrawAnImage original;

    public WatermarkedImage(IDrawAnImage original)
    {
      this.original = original;
    }

    public void draw(IRenderToADrawingSurface surface)
    {
      original.draw(surface);
    }
  }

  public class VisibilityConstrainedImage : IDrawAnImage
  {
    IDrawAnImage original;
    IConstrainAnOperation constraint;

    public VisibilityConstrainedImage(IDrawAnImage original, IConstrainAnOperation constraint)
    {
      this.original = original;
      this.constraint = constraint;
    }

    public void draw(IRenderToADrawingSurface surface)
    {
      if (!constraint()) return;

      original.draw(surface);
    }
  }

  public interface IRunAQueryForAListOf<T>
  {
    IEnumerable<T> run(); 
  }

  public class GetListOfCustomers : IRunAQueryForAListOf<Customer>
  {
    public IEnumerable<Customer> run()
    {
      throw new NotImplementedException();
    }
  }
  public class TimedQueryForList<T> : IRunAQueryForAListOf<T>
  {
    IRunAQueryForAListOf<T> original;
    ITimeThings timer;

    public TimedQueryForList(IRunAQueryForAListOf<T> original, ITimeThings timer)
    {
      this.original = original;
      this.timer = timer;
    }

    public IEnumerable<T> run()
    {
      timer.start();
      var results = original.run();
      timer.stop();
      return results;
    }
  }

  public class TimedDrawing : IDrawAnImage
  {
    ITimeThings timer;
    IDrawAnImage original;

    public TimedDrawing(ITimeThings timer, IDrawAnImage original)
    {
      this.timer = timer;
      this.original = original;
    }

    public void draw(IRenderToADrawingSurface surface)
    {
      timer.start();
      original.draw(surface);
      var span = timer.stop();
    }
  }

  public interface IDispatchAMethodCall
  {
    void proceed();
  }

  public interface IAddBehaviourToAMethod
  {
    void decorate(IDispatchAMethodCall method); 
  }

  public class TimedMethod : IAddBehaviourToAMethod
  {
    ITimeThings timer;

    public TimedMethod(ITimeThings timer)
    {
      this.timer = timer;
    }

    public void decorate(IDispatchAMethodCall method)
    {
      timer.start();
      method.proceed();
      timer.stop();
    }
  }

  public class ConstrainedMethod : IAddBehaviourToAMethod
  {
    IConstrainAnOperation constraint;

    public ConstrainedMethod(IConstrainAnOperation constraint)
    {
      this.constraint = constraint;
    }

    public void decorate(IDispatchAMethodCall method)
    {
      if (!constraint()) return;

      method.proceed();
    }
  }
  public class Customer
  {
  }


  public interface ITimeThings
  {
    void start();
    TimeSpan stop();
  }

  public class ImageBuilder
  {
    Func<IDrawAnImage> image;

    public ImageBuilder(Func<IDrawAnImage> initial)
    {
      this.image = initial; 
    }

    public static ImageBuilder build_image(Func<IDrawAnImage> initial)
    {
      return new ImageBuilder(initial); 
    }

    public IDrawAnImage build()
    {
      return this.image();
    }

    public ImageBuilder apply_watermark()
    {
      return new ImageBuilder(() => new WatermarkedImage(this.image()));
    }

    public ImageBuilder visible_when(IConstrainAnOperation func)
    {
      return this;
    }

    public ImageBuilder scale_to(double d)
    {
      return this;
    }
  }

  public class Startup
  {
    public static void configure_images()
    {
      ImageBuilder.build_image(() => new NulloImage())
        .apply_watermark()
        .visible_when(() => Thread.CurrentPrincipal.IsInRole("admin"))
        .scale_to(0.25);
    }
  }

  public class NulloImage : IDrawAnImage
  {
    public void draw(IRenderToADrawingSurface surface)
    {
      throw new NotImplementedException();
    }
  }

  public class NulloTimer : ITimeThings
  {
    public void start()
    {
      throw new NotImplementedException();
    }

    public TimeSpan stop()
    {
      throw new NotImplementedException();
    }
  }
}