type Validator<TValue> = (value: TValue) => {
  isValid: boolean;
  message: string;
};

export default Validator;
