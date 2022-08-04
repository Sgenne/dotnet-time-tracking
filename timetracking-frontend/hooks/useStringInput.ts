import { useState } from "react";
import ControlledStateHandler from "../types/ControlledStateHandler";
import OnStringChange from "../types/OnStringChange";
import Validator from "../types/Validator";
import { noOpValidator } from "../utils/validators/NoOpValidator";

export interface useStringInputProps {
  defaultValue?: string;
  validator?: Validator<string>;
}

const useStringInput = ({
  defaultValue = "",
  validator = noOpValidator<string>,
}: useStringInputProps = {}): ControlledStateHandler<string> => {
  const [value, setValue] = useState(defaultValue);
  const [hasError, setHasError] = useState(false);
  const [errorMessage, setErrorMessage] = useState<string>();
  const [isTouched, setIsTouched] = useState(false);

  const changeHandler: OnStringChange = (newValue: string) => {
    setIsTouched(true);
    setValue(newValue);
    if (hasError) validate(newValue);
  };

  const blurHandler = () => {
    if (isTouched) validate(value);
  };

  const validate = (valueToValidate: string) => {
    const { message, isValid } = validator(valueToValidate);
    if (!isValid) {
      setHasError(true);
      setErrorMessage(message);
      return;
    }
    setHasError(false);
    setErrorMessage(undefined);
  };

  return {
    value,
    onChange: changeHandler,
    onBlur: blurHandler,
    hasError,
    errorMessage,
  };
};

export default useStringInput;
