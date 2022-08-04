import Validator from "./Validator";

export default interface TextInputProps {
  onChange: (value: string) => void;
  value: string;
  hasError?: boolean;
  onBlur: () => void
}
