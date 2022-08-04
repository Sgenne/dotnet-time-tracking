import Validator from "../../types/Validator";

export const noOpValidator = <TValue>(value: TValue) => ({
  isValid: true,
  message: "",
});
