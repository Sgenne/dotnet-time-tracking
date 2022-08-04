import Validator from "../../types/Validator";

const defaultErrorMessage: string = "The input cannot be empty.";

export const getNonEmptyStringValidator =
  (errorMessage: string = defaultErrorMessage) =>
  (str: string) =>
    str.length === 0
      ? { isValid: false, message: errorMessage }
      : { isValid: true, message: "" };

export const validateNonEmptyString: Validator<string> =
  getNonEmptyStringValidator(defaultErrorMessage);
