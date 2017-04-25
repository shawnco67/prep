module Automation
  module Compile
    class AspNetCompiler
      attr_reader :compile_unit

      def self.run(unit)
        new(unit).run
      end

      def initialize(compile_unit)
        @compile_unit = compile_unit
      end

      def run()
        options = []
        options << '-v /' 
        options << "-p #{compile_unit.intermediary_path}"
        options << '-u' if compile_unit.updateable
        options << '-f' if compile_unit.force
        options << compile_unit.target_path
        options << '-errorstack'

        result = options.join(" ")

        system("aspnet_compiler #{result}")
      end
    end
  end
end
