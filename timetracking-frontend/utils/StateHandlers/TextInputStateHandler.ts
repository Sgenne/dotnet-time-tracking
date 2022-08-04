import ControlledStateHandler from "../../types/ControlledStateHandler";
import Validator from "../../types/Validator";
import { noOpValidator } from "../validators/NoOpValidator";

export interface TextInputStateHandlerConstructorArgs {
    defaultValue?: string;
    validator?: Validator<string>;
}

export default class TextInputStateHandler implements ControlledStateHandler<string> {
  value: string;
  hasError: boolean;
  errorMessage: string | undefined;
  private readonly validator: Validator<string>;
  private isTouched: boolean = false;

  constructor({defaultValue = "", validator = noOpValidator<string>}: TextInputStateHandlerConstructorArgs) {
    this.value = defaultValue;
    this.validator = validator;
    this.hasError = false;
  }

  onChange = (newValue: string) => {
    // TODO: Validation if error exists, touched = true
    this.value = newValue;
  }
  onBlur = () => {
    if (!this.isTouched) return;

    this.validate()
  };

  private validate = () => {
    const {message, isValid} = this.validator(this.value);

    if (!isValid) {
      this.hasError = true;
      this.errorMessage = message;
      return;
    };

    this.hasError = false;
    this.errorMessage = undefined;
  }




}
